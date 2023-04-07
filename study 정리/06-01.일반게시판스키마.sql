-- �Ϲ� �Խ��� ��Ű��(������ ���� ����) ����

--. 1. ���� - drop table, drop sequence : ������ �������.
--   cascade : ������ �������� ����. CONSTRAINTS : ����
--   table : �����͸� �����ϱ� ���� ����
drop table board CASCADE CONSTRAINTS;
--   sequence : ���� ��ȣ
drop sequence board_seq;


-- 2. ���� - create table, create sequence : ������ �������.
--   varchar2 - 4000byte���� ����. ���� �ʼ�
--   no null : �ʼ� �Է�. primary key : ��Ű - not null + unique
--   sysdate : �ý����� ���� ��¥�� �ð� ������
--   hit : �⺻���� ����� ���� - hit�� �����Ͱ� ������ null�� �ȴ�.
--     : null ���� �Ұ�. hit = hit + 1
create table board(
  no number CONSTRAINT board_no_pk primary key,
  title VARCHAR2(300) not null,
  content VARCHAR2(2000) not null,
  writer VARCHAR2(30) not null,
  writeDate date default sysdate,
  hit NUMBER default 0,
  pw VARCHAR2(20)
);

create sequence board_seq;

-- 3. ���õ�����
--   seq.nextval -> ���� ���ڸ� �޾ƿ´�. ���ڰ� ��� ����. ���� 20���� ����� �д�.
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '�Խ���', '�Խ����Դϴ�.', 'ȫ�浿', '1111');
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '������ ������ ����', '�Խ����Դϴ�.', '������', '1111');
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '�޽� ��', '���� �����.', '������', '1111');
commit;

-- 4. ������ �˻�.
--   * : ��� ������ ǥ�� -> �ӵ��� �������� ������ �Ǳ� ������ ���忡�� �����Ѵ�.
select * from board;