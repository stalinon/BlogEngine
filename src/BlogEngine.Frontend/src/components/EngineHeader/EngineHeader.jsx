import { Theme, presetGpnDefault } from "@consta/uikit/Theme";
import { Text } from "@consta/uikit/Text";
import { Header, HeaderLogo, HeaderModule } from "@consta/uikit/Header";
import { Button } from "@consta/uikit/__internal__/src/components/Button/Button";
import { IconUser } from "@consta/uikit/IconUser";
import { IconAdd } from "@consta/uikit/IconAdd";
import { useState, useEffect, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { LoginModal } from "../Modals/LoginModal/LoginModal";
import { RegisterModal } from "../Modals/RegisterModal/RegisterModal";
import { Auth } from "../../lib/ApiClient";
import { User } from "@consta/uikit/User";
import { b64toBlob } from "../../lib/Helpers";
import { ContextMenu } from "@consta/uikit/ContextMenu";
import { IconArrowDown } from "@consta/uikit/IconArrowDown";
import { IconCommentStroked } from "@consta/uikit/IconCommentStroked";
import { IconDocFilled } from "@consta/uikit/IconDocFilled";
import { IconExit } from "@consta/uikit/IconExit";

export default function EngineHeader() {
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);
  const [user, setUser] = useState(null);
  const [menu, setMenu] = useState(false);
  const navigate = useNavigate();
  const adminItems = [
    {
      label: "Пользователи",
      onClick: () => navigate("/users"),
      rightIcon: IconUser,
    },
    { label: "Статьи", rightIcon: IconDocFilled },
    { label: "Комментарии", rightIcon: IconCommentStroked },
    {
      label: "Выйти",
      onClick: () => {
        Auth.exit();
        setUser(null);
        window.location.reload();
      },
      rightIcon: IconExit,
    },
  ];
  const userItems = [
    {
      label: "Выйти",
      onClick: () => {
        Auth.exit();
        setUser(null);
        window.location.reload();
      },
      rightIcon: IconExit,
    },
  ];
  const ref = useRef(null);

  useEffect(() => {
    !user &&
      Auth.me()
        .then((res) => {
          setUser(res.data);
        })
        .catch((err) => {});
  }, [user]);

  function renderRight() {
    if (user == null) {
      return (
        <>
          <HeaderModule indent="s">
            <Button
              size="m"
              view="secondary"
              form="round"
              label="Войти"
              iconLeft={IconUser}
              onClick={() => setIsLoginModalOpen(true)}
            />
          </HeaderModule>
          <HeaderModule indent="l">
            <Button
              size="m"
              view="primary"
              form="round"
              label="Зарегистрироваться"
              iconLeft={IconUser}
              onClick={() => setIsRegisterModalOpen(true)}
            />
          </HeaderModule>
        </>
      );
    } else {
      switch (user.role) {
        case 2: {
          return (
            <>
              <HeaderModule indent="s">
                <Button
                  size="m"
                  view="secondary"
                  form="round"
                  label="Войти"
                  iconLeft={IconUser}
                  onClick={() => setIsLoginModalOpen(true)}
                />
              </HeaderModule>
              <HeaderModule indent="l">
                <Button
                  size="m"
                  view="primary"
                  form="round"
                  label="Зарегистрироваться"
                  iconLeft={IconUser}
                  onClick={() => setIsRegisterModalOpen(true)}
                />
              </HeaderModule>
            </>
          );
        }
        case 1: {
          return (
            <>
              <HeaderModule indent="l">
                <User
                  avatarUrl={
                    user.image && URL.createObjectURL(b64toBlob(user.image))
                  }
                  name={user.nickname}
                  size="l"
                />
              </HeaderModule>

              <HeaderModule indent="s">
                <Button
                  style={{ zIndex: 999 }}
                  view="clear"
                  form="round"
                  ref={ref}
                  iconRight={IconArrowDown}
                  onClick={() => setMenu(!menu)}
                />
                <ContextMenu
                  isOpen={menu}
                  offset="xs"
                  size="m"
                  direction="downCenter"
                  items={userItems}
                  getItemLabel={(item) => item.label}
                  getItemRightIcon={(item) => item.rightIcon}
                  anchorRef={ref}
                />
              </HeaderModule>
            </>
          );
        }
        case 0: {
          return (
            <>
              <HeaderModule indent="s">
                <Button
                  size="m"
                  view="secondary"
                  form="round"
                  label="Опубликовать статью"
                  iconLeft={IconAdd}
                  onClick={() => navigate("/publish")}
                />
              </HeaderModule>
              <HeaderModule indent="l">
                <User
                  avatarUrl={
                    user.image && URL.createObjectURL(b64toBlob(user.image))
                  }
                  name={user.nickname}
                  size="l"
                />
              </HeaderModule>

              <HeaderModule indent="s">
                <Button
                  style={{ zIndex: 999 }}
                  view="clear"
                  form="round"
                  ref={ref}
                  iconRight={IconArrowDown}
                  onClick={() => setMenu(!menu)}
                />
                <ContextMenu
                  isOpen={menu}
                  offset="xs"
                  size="m"
                  direction="downCenter"
                  items={adminItems}
                  getItemLabel={(item) => item.label}
                  getItemRightIcon={(item) => item.rightIcon}
                  anchorRef={ref}
                />
              </HeaderModule>
            </>
          );
        }
      }
    }
  }

  return (
    <Theme className="App" preset={presetGpnDefault}>
      <Header
        leftSide={
          <>
            <HeaderModule>
              <HeaderLogo>
                <Text as="p" size="l" weight="bold">
                  Logotype
                </Text>
              </HeaderLogo>
            </HeaderModule>
          </>
        }
        rightSide={renderRight()}
      />
      <LoginModal
        isOpen={isLoginModalOpen}
        onClickOutside={() => setIsLoginModalOpen(false)}
        onEsc={() => setIsLoginModalOpen(false)}
      />
      <RegisterModal
        isOpen={isRegisterModalOpen}
        onClickOutside={() => setIsRegisterModalOpen(false)}
        onEsc={() => setIsRegisterModalOpen(false)}
      />
    </Theme>
  );
}
